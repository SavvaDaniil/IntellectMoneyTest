# IntellectMoneyTest
Test for company "IntellectMoney"

#Initial data:

1. There is a list of email addresses. There are several million of them.
2. There is a ready-made text of the letter. Full. Not a template.
3. There is a method that can send a letter and answer whether it was successful or not.

#What should be done

It is necessary to make a service that will send out the text of the letter to all email addresses. Strictly once. Guaranteed (we guarantee shipment).

#Requirements:

1. Guaranteed dispatch (the dispatch service replied that the message had been sent)
2. Sending must be guaranteed ONE.
3. Since there are many addresses, you need to implement multi-threaded sending
4. It is necessary to provide for a power outage. It means that after the service is restored, the distribution should continue without violating the requirements.

It is not necessary to make a complete implementation. But I would like to see the general architecture, classes, methods, method parameters. Descriptions in the form of comments of places where the implementation should be (explanations on algorithms).
If you need several projects in the solution, then justify each with a comment.
If there are any table-type artifacts, it is important to see their description. Here you need more details, with types, names and everything you can.
There are no limits in .net technologies. It is advisable to think carefully about which and why to use and explain the choice.
