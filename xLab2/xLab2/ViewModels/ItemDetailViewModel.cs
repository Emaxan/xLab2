using System;

namespace xLab2
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public City Item { get; set; }
        public ItemDetailViewModel(City item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
