using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using nexTwitter.Infrastructure.Data;

namespace nexTwitter.Data.SqlServer.Migrations
{
    [ContextType(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("nexTwitter.Domain.Entities.Tweet", b =>
                    {
                        b.Property<string>("CreatedBy")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<DateTime>("DateCreated")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<bool>("IsActive")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<bool>("IsDeleted")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<DateTime>("LastModified")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<string>("Text")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("UpdatedBy")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<int>("UserId")
                            .Annotation("OriginalValueIndex", 8);
                        b.Key("Id");
                    });
                
                builder.Entity("nexTwitter.Domain.Entities.User", b =>
                    {
                        b.Property<string>("Country")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("CreatedBy")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<DateTime>("DateCreated")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<DateTime>("DateOfBirth")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("Email")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 5)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<bool>("IsActive")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<bool>("IsDeleted")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<DateTime>("LastModified")
                            .Annotation("OriginalValueIndex", 8);
                        b.Property<string>("Password")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<string>("UpdatedBy")
                            .Annotation("OriginalValueIndex", 10);
                        b.Property<string>("Username")
                            .Annotation("OriginalValueIndex", 11);
                        b.Key("Id");
                    });
                
                builder.Entity("nexTwitter.Domain.Entities.UserWithFollower", b =>
                    {
                        b.Property<string>("CreatedBy")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<DateTime>("DateCreated")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("FollowerId")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<bool>("IsActive")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<bool>("IsDeleted")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<DateTime>("LastModified")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("UpdatedBy")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<int?>("UserFollowerId")
                            .Annotation("OriginalValueIndex", 8)
                            .Annotation("ShadowIndex", 0);
                        b.Property<int>("UserId")
                            .Annotation("OriginalValueIndex", 9);
                        b.Key("Id");
                    });
                
                builder.Entity("nexTwitter.Domain.Entities.UserWithTweet", b =>
                    {
                        b.Property<string>("CreatedBy")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<DateTime>("DateCreated")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<bool>("IsActive")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<bool>("IsDeleted")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<DateTime>("LastModified")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<int>("TweetId")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("UpdatedBy")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<int>("UserId")
                            .Annotation("OriginalValueIndex", 8);
                        b.Key("Id");
                    });
                
                builder.Entity("nexTwitter.Domain.Entities.Tweet", b =>
                    {
                        b.ForeignKey("nexTwitter.Domain.Entities.User", "UserId");
                    });
                
                builder.Entity("nexTwitter.Domain.Entities.UserWithFollower", b =>
                    {
                        b.ForeignKey("nexTwitter.Domain.Entities.User", "UserFollowerId");
                        b.ForeignKey("nexTwitter.Domain.Entities.User", "UserId");
                    });
                
                builder.Entity("nexTwitter.Domain.Entities.UserWithTweet", b =>
                    {
                        b.ForeignKey("nexTwitter.Domain.Entities.Tweet", "TweetId");
                        b.ForeignKey("nexTwitter.Domain.Entities.User", "UserId");
                    });
                
                return builder.Model;
            }
        }
    }
}
