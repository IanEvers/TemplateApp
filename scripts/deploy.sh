set +x
OS=$(uname -s)

echo "Operating system is $OS"

# cd into correct directory
project=FileConverter
cd $project || exit 1

FILE="$project.csproj"  # Specify the path to your XML file

# Read the current version
current_version=$(sed -n 's|.*<Version>\(.*\)</Version>.*|\1|p' "$FILE")

# Increment the version
# Assuming the version format is Major.Minor.Patch, we'll increment the Patch number
IFS='.' read -ra ADDR <<< "$current_version"
major=${ADDR[0]}
minor=${ADDR[1]}
patch=${ADDR[2]}
let "patch+=1"

# sed is different on MacOS and Ubuntu (GH actions) so we need this conditional
if [ "$OS" = "Darwin" ]; then
    echo "Running on macOS"
    # Use sed to replace the version in the file
    sed -i '' "s|<Version>$current_version</Version>|<Version>$major.$minor.$patch</Version>|g" "$FILE"
    sed -i '' "s|<AssemblyName>.*</AssemblyName>|<AssemblyName>$COMPANY</AssemblyName>|g" "$FILE"

elif [ "$OS" = "Linux" ]; then
    sed -i "s|<Version>$current_version</Version>|<Version>$major.$minor.$patch</Version>|g" "$FILE"
else
    echo "Unknown operating system: $OS"
    exit 1
fi

dotnet publish --configuration Release || exit 1
(cd bin/Release/net8.0/publish && zip -r "../../../../../blackbird_app3.zip" .) || exit 1
echo "Published Blackbird app v$major.$minor.$patch => blackbird_app3.zip"
