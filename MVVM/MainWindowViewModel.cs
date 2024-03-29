﻿using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TemporalTableTest
{
    public class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            PostNewCommand = new DelegateCommand<int>(ToPostEditNew);
            PostCancelCommand = new DelegateCommand<int>(ToPostList);
            PostSubmitCommand = new DelegateCommand<int>(Submit);
        }

        public ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();

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
        /// Postのタイトル
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Postの内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Postを新規作成する際のId。 
        /// CommandParameter="-1"とすると、string->object->intでInvalidCastExceptionが
        /// 発生するので、回避。
        /// </summary>
        public int PostId { get; set; } = -1;

        /// <summary>
        /// Postを新規作成する際のコマンド
        /// </summary>
        public ICommand PostNewCommand { get; private set; }

        /// <summary>
        /// Post新規作成画面を表示する
        /// </summary>
        /// <param name="postId"></param>
        private void ToPostEditNew(int postId)
        {
            ViewType = ViewTypes.PostEdit;
        }

        /// <summary>
        /// Postを新規作成する際のコマンド
        /// </summary>
        public ICommand PostCancelCommand { get; private set; }

        /// <summary>
        /// Post一覧を表示する
        /// </summary>
        /// <param name="postId"></param>
        private void ToPostList(int postId)
        {
            ViewType = ViewTypes.PostList;
        }

        /// <summary>
        /// Postを送信（追加）するコマンド
        /// </summary>
        public ICommand PostSubmitCommand { get; private set; }

        /// <summary>
        /// Postを追加する
        /// </summary>
        /// <param name="postId"></param>
        private void Submit(int postId)
        {
            if (Title.Length == 0 || Content.Length == 0)
                return;

            Posts.Add(new Post { Title = Title, Content = Content });
            ViewType = ViewTypes.PostList;

            Title = Content = "";
        }
    }
}
