using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using FluentAssertions;
using System;
using System.Collections.Generic;
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
            var activity = new Activity(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "Nume activitate",
                "Adresa activitate",
                "Descriere activitate"
                );
            var comment = new Comment(
                activity.Id,
                this.AuthenticatedUserId
                );
            activity.AddComment(comment);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            // Act
            var response = await HttpClient.GetAsync($"api/v1/activities/{activity.Id}/comments");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var comments = await response.Content.ReadAsAsync<IList<CommentModel>>();
            comments.Should().HaveCount(1);
        }
    }
}
