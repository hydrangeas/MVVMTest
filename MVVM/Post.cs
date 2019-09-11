using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalTableTest
{
    public class Post
    {
        /// <summary>
        /// ポストID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
