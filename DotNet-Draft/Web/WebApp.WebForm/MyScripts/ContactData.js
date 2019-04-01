'use strict';

contactsApp.factory('contactData', function () {
    var contacts = [
        {
            first: "Chris",
            last: "Okelberry",
            address: "8467 Cliford Court",
            city: "Redmond",
            state: "Washington",
            zipCode: 98052,
            cellPhone: 3155550144,
            homePhone: 3155550144,
            workPhone: 3155550144
        },
        {
            first: "Kim",
            last: "Abercrombie",
            address: "9752 Jeanne Circle",
            city: "Carnation",
            state: "Washington",
            zipCode: 98014,
            cellPhone: 2085550144,
            homePhone: 2085550144,
            workPhone: 2085550144
        },
        {
            first: "Ed",
            last: "Dudenhoefer",
            address: "4598 Manila Avenue",
            city: "Seattle",
            state: "Washington",
            zipCode: 98104,
            cellPhone: 9195550140,
            homePhone: 9195550140,
            workPhone: 9195550140
        },
        {
            first: "JoLynn",
            last: "Dobney",
            address: "7126 Ending Ct.",
            city: "Seattle",
            state: "Washington",
            zipCode: 98104,
            cellPhone: 9035550145,
            homePhone: 9035550145,
            workPhone: 9035550145
        },
        {
            first: "Bryan",
            last: "Baker",
            address: "2275 Valley Blvd.",
            city: "Monroe",
            state: "Washington",
            zipCode: 98272,
            cellPhone: 7125550113,
            homePhone: 7125550113,
            workPhone: 7125550113
        }
    ];

    return {
        getContacts: function () {
            return contacts;
        },
        addContact: function (contact) {
            contacts.push(contact);
            return contacts;
        }
    };
});