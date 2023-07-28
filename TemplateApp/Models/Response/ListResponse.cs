namespace TemplateApp.Models.Response;

public class ListResponse<T>
{
    public T[] Results { get; set; }
}