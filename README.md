# BlogCoreAPI
A simple open source BlogAPI written in .NET Core 2.2

# Setup to run it on you Computer
You need the .NET Core 2.2 SDK (Download: https://dotnet.microsoft.com/download) and the Microsoft Sql Server (Download: https://www.microsoft.com/en-au/sql-server/sql-server-downloads *Free Developer Version)

# HTTP Request

# Posts:

GET bca/posts
- Get all Posts

GET bca/posts/[PostID]
- Get the Post with this PostID

POST bca/posts
- Post Data

PUT bca/posts/[PostID]
- Put Data at this PostID

DELETE bca/posts/[PostID]
- Delete the Post with this PostID

# Comments:

GET bca/comments
- Get all Comments

GET bca/comments/[PostID]
- Get all Comments from the Post with this ID

POST bca/comments/[PostID]
- Post Comment to the Post with this PostID

PUT bca/comments/[CommentID]
- Put Comment at this CommentID

DELETE bca/comments/[CommentID]
- Delete the Comment with this CommentID
