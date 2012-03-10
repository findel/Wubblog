Wubblog
=======

*Wubblog* is (read **will be** because there's not much to it yet) a lightweight blogging solution built using 
ASP.NET 4.0, NancyFx, Simple.Data and MySql. It's also built on top of the 'responsive' initializr.com template (see [ResponsiveMVC](https://github.com/findel/ResponsiveMVC)). 

(I'll now switch to future tense, because as I said - there's really not much to it yet.)

*Wubblog* will not be an engine-like project which would be installed and able to receive updates, 
but rather a 'starter' project for you to build on top of.

Of course, if you want to receive changes from the upstream (if and when they are made), 
you can fork the project and maintain your own version in a separate branch. 
You'll be entirely in control of (and responsible for) merging changes into your own branch.

There are three projects:

### Wubblog.Web

This will be the main (public) blog project. 

### Wubblog.Admin

This will be the project used by the blog administrator(s) to edit content and so on. Administrators, or `Authors`, will be required to sign in to use this site.

I've decided I will use a separate project for this because I prefer the added security through obscurity that I feel it provides, since it can be run on a completely separate domain. For example, on my blog I plan on running this as a not too obvious sub-domain. 

### Wubblog.Library 

This is the library project that is shared between `Wubblog.Web` and `Wubblog.Admin`. This will be where the main classes/models and data access layer will live. ViewModels specific to `Wubblog.Web` or `Wubblog.Admin` will not be found in this library.

### MySql Schema

I've decided to use MySql (and innoDB) because it's something I'm familiar with. Of course Simple.Data can be used with many other data sources, so hopefully it won't be too hard to switch to another Simple.Data adapter of your preference. I'm using the Simple.Data.Mysql adapter. 

SQL scripts can be found in `/src/sql`. 

The `create.sql` script is used to create a fresh schema with no data. The `data.sql` file can be used to set up the schema with test data. 