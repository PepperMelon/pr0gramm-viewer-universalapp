using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.ExtendedClasses
{
    using System.Collections.ObjectModel;
    using Windows.Foundation;
    using Windows.UI.Xaml.Data;

    public class IncrementalObservableCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        private readonly Func<bool> hasMoreItems;
        private readonly Func<uint, IAsyncOperation<LoadMoreItemsResult>> loadMoreItems;

        public IncrementalObservableCollection(Func<bool> hasMoreItems, Func<uint, IAsyncOperation<LoadMoreItemsResult>> loadMoreItems)
        {
            this.hasMoreItems = hasMoreItems;
            this.loadMoreItems = loadMoreItems;
        }

        public bool HasMoreItems
        {
            get { return hasMoreItems(); }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return loadMoreItems(count);
        }
    }
}
