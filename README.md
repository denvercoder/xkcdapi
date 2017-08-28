# xkcdapi
XKCD API in Asp.net Core 2.0 using azure for the datastore.

# Purpose
I really enjoy the xkcd comics and since I was studying iOS development I decided 
it would be cool to build an iOS xkcd reader. Through the process of developing 
the app I found out that the xkcd "API" can only fetch the latest comic and each 
individual comic by number.

I soon realized that it would take 1800 requests to the server to get all of the
comics to populate a tableview. And that was for each device that loaded the app!

Not wanting to overload anyones server I saw that I would have to essentially 
write my own API that would have a copy of the official xkcd API in a database.

So that is what I did. With my API you can fetch a single comic by number or
you can fetch them all.

This is just a first version and I plan on implementing the ability to paginate
the results so that you can request a few comics at a time. I also plan on eventually
implementing a search that will allow someone to search based on keywords.

For now, I have this working and it will poll the official xkcd API every 6 hours.
Since the comics are released every Monday, Wednesday and Friday, I think getting
new comics every 6 hours should be fine.

I want to thank Randall Munroe, first of all for writing an awesome comic. Secondly,
I would like to thank him for not freaking out about people using his stuff for
non-commercial purposes.

Please visit https://xkcd.com/ if you haven't been there before you will enjoy it
I promise. If you _have_ been there before, why not go back and check it out!

# Project
my website/api is located here:
http://xkcdapi20170825022619.azurewebsites.net/

Thanks

