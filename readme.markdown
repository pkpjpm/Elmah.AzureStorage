Elmah-Azure Storage
===================
This project was inspired by [Wade Wegner's original Elmah Table Storgate implementation] (http://www.wadewegner.com/2011/08/using-elmah-in-windows-azure-with-table-storage/ "Using Elmah in Windows Azure with Table Storage"). While using Wade's implementation, I came across a few limitations, including:
+ The key generation strategy assumes that 2 errors will never occur within the same "tick" of the system clock. I've seen this assumption fail even on a single machine, and in a server farm collisions are certainly possible.
+ The size constraints of Windows Azure table storage are not taken into account. As a result, logging of exceptions with very large amounts of data from inner excetions, etc. can fail. This creates a situation where the most valuable expections might be lost.
+ All table writes are made in one default partition - this makes storage management more difficult.
+ The original implementation make no effort to count exceptions, which disables the paging feature of Elmah.
+ This new library will use the latest Azure storage client (starting with 2.0, and updating as we go)
Last but not least, I know that other devs have been looking for an Azure storage/Elmah solution. By establishing this repo, I hope to provide a convenient place for contributors to add features. 
