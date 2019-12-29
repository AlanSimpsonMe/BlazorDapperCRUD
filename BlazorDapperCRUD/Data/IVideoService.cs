using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDapperCRUD.Data
{
    // Each item below provides an interface to a method in VideoServices.cs
    public interface IVideoService
    {
        Task<bool> VideoInsert(Video video);
        Task<IEnumerable<Video>> VideoList();
        Task<Video> Video_GetOne(int Id);
        Task<bool> VideoUpdate(Video video);
        Task<bool> VideoDelete(int id);
    }
}