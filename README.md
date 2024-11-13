Needs local db. In appsettings.json change AuctionDbContext under ConnectionStrings to your local db.
After connecting the local db in the Developer PowerShell enter 'cd DAL' and 'dotnet ef database update --startup-project ../Auction --context AuctionDbContext'

Dropzone click-to-select crashes app, drag-and-drop works.
