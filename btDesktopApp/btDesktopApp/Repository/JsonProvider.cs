using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using btDesktopApp.Models;
using btDesktopApp.Services;
using System.Net.Http;
using System.Net;
using System.IO;

namespace btDesktopApp.Repository
{
    public class JsonProvider : IDataProvider
    {
        private const string SERVERURL = "http://jsonplaceholder.typicode.com";

        private readonly ISerializer _serializer;

        string getResponse(string uri)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Method = "GET";
            var response =  request.GetResponse();
            var stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            return  sr.ReadToEnd();
        }
        public JsonProvider(ISerializer serializer)
        {
            _serializer = serializer;
        }
        public Comment Comment(int id)
        {
            var json = getResponse(SERVERURL + $"/comments/{id}/");
            return _serializer.Deserialize<Comment>(json);
        }
        public IEnumerable<Comment> Comments()
        {
            var json = getResponse(SERVERURL + "/comments/");
            return _serializer.Deserialize<IEnumerable<Comment>>(json);
        }
        public Post Post(int id)
        {
            var json = getResponse(SERVERURL + $"/posts/{id}/");
            return _serializer.Deserialize<Post>(json);
        }
        public IEnumerable<Comment> PostComments(int id)
        {
            var json = getResponse(SERVERURL + $"/posts/{id}/comments/");
            return _serializer.Deserialize<IEnumerable<Comment>>(json);
        }
        public IEnumerable<Post> Posts()
        {
            var json = getResponse(SERVERURL + "/posts/");
            return _serializer.Deserialize<IEnumerable<Post>>(json);
        }
        public User User(int id)
        {
            var json = getResponse(SERVERURL + $"/users/{id}");
            return _serializer.Deserialize<User>(json);
        }
        public IEnumerable<Post> UserPosts(int id)
        {
            var json = getResponse(SERVERURL + $"/posts?userId={id}");
            return _serializer.Deserialize<IEnumerable<Post>>(json);
        }
        public IEnumerable<User> Users()
        {
            var json = getResponse(SERVERURL + "/users/");
            return _serializer.Deserialize<IEnumerable<User>>(json);
        }              
        //ASYNC
        async Task<string> getResponseAsync(string uri)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Method = "GET";
            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            return await sr.ReadToEndAsync();
        }

        async public Task<IEnumerable<Post>> PostsAsync()
        {
            var json = await getResponseAsync(SERVERURL + "/posts/");
            return _serializer.Deserialize<IEnumerable<Post>>(json);
        }

        async public Task<IEnumerable<Comment>> CommentsAsync()
        {
            var json = await getResponseAsync(SERVERURL + "/comments/");
            return _serializer.Deserialize<IEnumerable<Comment>>(json);
        }

        async public Task<IEnumerable<User>> UsersAsync()
        {
            var json = await getResponseAsync(SERVERURL + "/users/");
            return _serializer.Deserialize<IEnumerable<User>>(json);
        }

        async public Task<IEnumerable<Post>> UserPostsAsync(int id)
        {
            var json = await getResponseAsync(SERVERURL + $"/posts?userId={id}");
            return _serializer.Deserialize<IEnumerable<Post>>(json);
        }

        async public Task<IEnumerable<Comment>> PostCommentsAsync(int id)
        {
            var json = await getResponseAsync(SERVERURL + $"/posts/{id}/comments/");
            return _serializer.Deserialize<IEnumerable<Comment>>(json);
        }

        async public Task<Comment> CommentAsync(int id)
        {
            var json = await getResponseAsync(SERVERURL + $"/comments/{id}/");
            return _serializer.Deserialize<Comment>(json);
        }

        async public Task<Post> PostAsync(int id)
        {
            var json = await getResponseAsync(SERVERURL + $"/posts/{id}/");
            return _serializer.Deserialize<Post>(json);
        }

        async public Task<User> UserAsync(int id)
        {
            var json = await getResponseAsync(SERVERURL + $"/users/{id}");
            return _serializer.Deserialize<User>(json);
        }
    }
}
