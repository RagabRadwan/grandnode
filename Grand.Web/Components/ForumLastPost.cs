﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Grand.Web.Services;
using System.Linq;
using Grand.Core.Domain.Forums;
using Grand.Services.Forums;

namespace Grand.Web.ViewComponents
{
    public class ForumLastPostViewComponent : ViewComponent
    {
        private readonly IForumService _forumService;
        private readonly IBoardsWebService _boardsWebService;
        public ForumLastPostViewComponent(IForumService forumService, IBoardsWebService boardsWebService)
        {
            this._forumService = forumService;
            this._boardsWebService = boardsWebService;
        }

        public IViewComponentResult Invoke(string forumPostId, bool showTopic)
        {
            var post = _forumService.GetPostById(forumPostId);
            var model = _boardsWebService.PrepareLastPost(post, showTopic);
            return View(model);

        }
    }
}