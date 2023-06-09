namespace BonayogDianaFinalExam.Manage
{
    public interface IUserService : IService
    {
        Paged<UserDto> Search(int? pageIndex = 1,
                             int? pageSize = 10,
                             string? sortBy = "",
                             SortOrder sortOrder = SortOrder.Ascending,
                             string? keyword = "");

        Guid? Create(UserDto? dto);
        Guid? Update(UserDto? dto);
        Guid? Delete(Guid? userId);
        UserDto? GetById(Guid? userId);
    }
}