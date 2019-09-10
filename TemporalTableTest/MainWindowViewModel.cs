namespace TemporalTableTest
{
    public class MainWindowViewModel: ViewModelBase
    {
        /// <summary>
        /// 表示画面タイプ
        /// </summary>
        public enum ViewTypes : int
        {
            /// <summary>
            /// 一覧表示画面
            /// </summary>
            PostList = 0,
            /// <summary>
            /// 新規、更新画面
            /// </summary>
            PostEdit,
            /// <summary>
            /// 履歴画面
            /// </summary>
            PostHistory
        }

        private ViewTypes _ViewType = ViewTypes.PostList;
        /// <summary>
        /// 表示画面のタイプ
        /// </summary>
        public ViewTypes ViewType
        {
            get => _ViewType;
            set
            {
                if (value == _ViewType)
                    return;
                _ViewType = value;
            }
        }
    }
}
