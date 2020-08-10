using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class CommentsControllerTests: IntegrationTests
    {
        [Fact]
        public async Task GetActivityComments()
        {
            // Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);
            var comment = CommentFactory.Default(activity.Id, AuthenticatedUserId);
            activity.AddComment(comment);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            // Act
            var response = await HttpClient.GetAsync($"/api/v1/activities/{activity.Id}/comments");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var comments = await response.Content.ReadAsAsync<IList<Comment>>();
            comments.Should().HaveCount(1);
        }

        [Fact]
        public async Task AddCommentsToActivity()
        {
            // Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });
            var newCommentModel = new NewCommentModel()
            {
                Content = "commentariu",
                UserId = AuthenticatedUserId
            };

            // Act
            var response = await HttpClient.PostAsJsonAsync($"api/v1/activities/{activity.Id}/comments", newCommentModel);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var createdCommentId = response.Headers.Location.OriginalString;
            Comment existingComment = null;
            await ExecuteDatabaseAction(async (doFestContext) => {
                var existingActvity = await doFestContext
                                        .Activities
                                        .Include(entity => entity.Comments)
                                        .FirstAsync(entity => entity.Id ==activity.Id);

                existingComment = existingActvity.Comments.FirstOrDefault();
            });
            existingComment.Should().NotBeNull();
            existingComment.Id.Should().Be(createdCommentId);
        }

        [Fact]
        public async Task DeleteCommentFromActivity()
        {
            // Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);
            var comment = CommentFactory.Default(activity.Id, AuthenticatedUserId);
            activity.AddComment(comment);
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            // Act
            var response = await HttpClient.DeleteAsync($"api/v1/activities/{activity.Id}/comments/{comment.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            Activity existingActvity = null;
            Comment existingComment = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                existingActvity = await doFestContext
                                        .Activities
                                        .Include(entity => entity.Comments)
                                        .FirstAsync(entity => entity.Id == activity.Id);
                existingComment = existingActvity.Comments.FirstOrDefault();
            });
            existingActvity.Comments.Should().HaveCount(0);
            existingComment.Should().BeNull();
        }

        [Fact]
        public async Task DeleteInvalidCommentFromAcvtivity()
        {
            // Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);
            var comment = CommentFactory.Default(activity.Id, AuthenticatedUserId);
            activity.AddComment(comment);
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            // Act
            var response = await HttpClient.DeleteAsync($"api/v1/activities/{activity.Id}/comments/{Guid.NewGuid()}");

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task AddCommentsToInvalidActivityId()
        {
            // Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });
            var newCommentModel = new NewCommentModel()
            {
                Content = "commentariu",
                UserId = AuthenticatedUserId
            };

            // Act
            var response = await HttpClient.PostAsJsonAsync($"api/v1/activities/{Guid.NewGuid()}/comments", newCommentModel);

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task GetInvalidActivityIdComments()
        {
            // Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);
            var comment = CommentFactory.Default(activity.Id, AuthenticatedUserId);
            activity.AddComment(comment);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            // Act
            var response = await HttpClient.GetAsync($"/api/v1/activities/{Guid.NewGuid()}/comments");

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}
