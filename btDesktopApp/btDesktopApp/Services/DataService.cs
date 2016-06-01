using System;
using System.Collections.Generic;
using System.Linq;
using btDesktopApp.Models;
using btDesktopApp.Repository;
using System.Timers;

namespace btDesktopApp.Services
{
    public class DataService : IDataService
    {
        IDataProvider _dataProvider;
        List<User> _users;
        List<Post> _posts;
        List<Comment> _comments;

        Timer t = new Timer(1000 * 60 * 3);

        public DataService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            t.Elapsed += clearCache;
            t.AutoReset = true;
            t.Start();
        }
        private void clearCache(object sender, ElapsedEventArgs e)
        {
            _users?.Clear();
            _posts?.Clear();
            _comments?.Clear();
        }

        public IEnumerable<User> GetUsers()
        {
            if (_users == null || _users.Count() <= 0)
            {
                _users = _dataProvider.Users().ToList();
            }
            return _users;
        }

        public IEnumerable<Post> GetPosts()
        {
            if (_posts == null || _posts.Count() <= 0)
            {
                _posts = _dataProvider.Posts().ToList();
            }
            return _posts;
        }
        public IEnumerable<Post> GetUsersPost(int userid)
        {
            if (_posts == null || _posts.Count() <= 0)
            {
                _posts = _dataProvider.Posts().ToList();
            }
            return _posts.Where(x => x.userid == userid);
        }
        public Dictionary<string, int> GetStatisticsForPost(int postid, int topLimit = 10)
        {
            var post = GetPosts().FirstOrDefault(x=> x.id == postid);
            var comments = GetPostsComments(postid);
            var body = (post.body + string.Join(" ", comments.Select(x => x.body))).Replace('\n', ' ').Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var topWords = body.GroupBy(x => x).OrderByDescending(y => y.Count()).Take(topLimit);
            Dictionary<string, int> result = topWords.Select(x =>
            {
                int count = x.Count();
                return new { x.Key, count };
            }).ToDictionary(y => y.Key, y => y.count);
            return result;
        }
        public IEnumerable<Comment> GetPostsComments(int postid)
        {
            if (_comments == null || _comments.Count() <= 0)
            {
                _comments = _dataProvider.Comments().ToList();
            }
            return _comments.Where(x=> x.postid == postid);
        }
    }
}
