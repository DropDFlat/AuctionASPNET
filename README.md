Needs local db. In appsettings.json change AuctionDbContext under ConnectionStrings to your local db.
After connecting the local db in the Developer PowerShell enter 'cd DAL' and 'dotnet ef database update --startup-project ../Auction --context AuctionDbContext'

Dropzone click-to-select might crash the app, drag-and-drop works.

Images can be uploaded when editing auctions.
To edit an auction click on the auction in the table, if the logged in user created the auction the edit button will be visible at the bottom of the page.
