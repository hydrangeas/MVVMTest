using System.Windows.Input;

namespace TemporalTableTest
{
    public class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            PostNewCommand = new DelegateCommand<int>(SwitchPostView);
        }

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
                RaisePropertyChanged(nameof(ViewType));
            }
        }

        /// <summary>
        /// Postを新規作成する際のId。 
        /// CommandParameter="-1"とすると、string->object->intでInvalidCastExceptionが
        /// 発生するので、回避。
        /// </summary>
        public int NewPostId { get; } = -1;

        /// <summary>
        /// Postを新規作成する際のコマンド
        /// </summary>
        public ICommand PostNewCommand { get; private set; }

        /// <summary>
        /// Postビューを切り替える
        /// </summary>
        /// <param name="postId"></param>
        private void SwitchPostView(int postId)
        {
            if (postId == -1)
            {
                // -1は無条件に新規作成
                ViewType = ViewTypes.PostEdit;
            }
        }
    }
}
