namespace Domain.ViewModels.Paging.Pagination
{
    public class Pagination<T>
    {
        public Pagination()
        {
            PageId = 1;
            TakeEntity = 10;
            HowManyShowAfterAndBefore = 5;
            Entities = new List<T>();
        }
        public int PageId { get; set; }
        public int PageCount { get; set; }
        public int AllEntitiesCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int TakeEntity { get; set; }
        public int SkipEntity { get; set; }
        public int HowManyShowAfterAndBefore { get; set; }
        public List<T> Entities { get; set; }


        public async Task<Pagination<T>> Paging(IQueryable<T> querable)
        {


            PageCount = Convert.ToInt32(Math.Ceiling((double)(querable.Count()) / (double)TakeEntity));

            if (PageId > PageCount)
            {
                PageId = PageCount;
            }
            else
            {
                PageId = PageId;
            }
            if (PageId <= 0)
            {
                PageId = 1;
            }
            AllEntitiesCount = querable.Count();

            if (PageCount < 0)
            {
                throw new Exception();
            }

            TakeEntity = TakeEntity;

            HowManyShowAfterAndBefore = HowManyShowAfterAndBefore;

            SkipEntity = TakeEntity * (PageId - 1);

            StartPage = PageId - HowManyShowAfterAndBefore <= 0 ? 1 : PageId - HowManyShowAfterAndBefore;

            EndPage = PageId + HowManyShowAfterAndBefore >= PageCount ? PageCount : PageId + HowManyShowAfterAndBefore;

            Entities = querable.Skip(SkipEntity).Take(TakeEntity).ToList();

            return this;

        }
        public PagingViewModel GetCurrentPaging()
        {
            return new PagingViewModel()
            {
                EndPage = EndPage,
                CurrentPage = PageId,
                PageCount = PageCount,
                StartPage = StartPage
            };
        }
    }
    public class PagingViewModel
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
