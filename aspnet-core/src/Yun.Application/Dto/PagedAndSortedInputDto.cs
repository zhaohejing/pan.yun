using Abp.Application.Services.Dto;

namespace Yun.Dto
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = 10;
        }
    }
}