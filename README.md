# Sitecore.Content-as-a-Service
Hobby project which tries to replace the entire data layer of Sitecore by a modern data layer which runs in clouds such as Azure and AWS. Don't use this in a production instance. This is just research fun, completely seperate from Sitecore.
I set the following goals for the project:

* Unit test coverage of 90%+ for logic (ignore integration pieces with Sitecore)
* Backwards compatible with existing data structures
* Support for in-memory to allow easy development
* Support for cloud deployment including integration testing and support for both inmutable infrastructure and high availability setups
* Quick (In-Memory: Insert of 10K items < 2 minutes; Cloud: Insert of 10K Items < 1 minutes)
* Lineair scalable (Time(Insert 1M items) = 1000 * Time(Insert 1K Item)
* 
## Licensing & contribution
Feel free to use this for your own fun, to contribute or to qive critiques. Just be aware that this work is done free of charge and acts as a R&D project. All work is performed not being paid by the Sitecore Corporation, neither under super vision of Sitecore Corporation. All software will be released under the MIT license. Not that this project will never try to violate Sitecore's EULA or Sitecore's Interlectual Properties. If it happens to be crossing a line, the project owner can be contacted and the source code will be taken offline.
