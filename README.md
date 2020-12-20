# Pakeliui

KA projektas

Backend:

- cd ./back-end
- dotnet run
- https://localhost:5001/api/User/AllUsers

Cars:

- get: https://localhost:5001/api/Car/AllCars
- post: https://localhost:5001/api/Car
- obj for post: {
  "model": "Volvo",
  "manufacturer": "Blue",
  "date": 2012,
  "color": "blue",
  "picturePath": "test"
  }
- put: https://localhost:5001/api/Car
- obj for put: {
  "id": 4,
  "model": "Volvo",
  "manufacturer": "Blue",
  "date": 2012,
  "picturePath": "test"
  }
- delete: https://localhost:5001/api/Car
- obj for delete: { "id": 5 }

Posts:

- get: https://localhost:5001/api/Post/AllPosts
- getByPassengerId: https://localhost:5001/api/post/GetPostsByPassengerId?id=4
- getById: https://localhost:5001/api/post/?id=2
- getByAuthorId: https://localhost:5001/api/post/GetByAuthorId?id=1
- post: https://localhost:5001/api/Post
- obj for post : {
  "price": 100,
  "seetCount": 4,
  "date": "2020-12-15T00:00:00",
  "time": "2020-12-15T00:00:00",
  "info": "idomi informacija",
  "dropoff": "Ismetimo vieta",
  "travelFrom": "Kaunas",
  "travelTo": "Vilnius",
  "pickup": "Stotele",
  "userId": 1,
  "user": null,
  "passengers": [
  {
  "id": 2,
  "passengerId": 1,
  "postId": 2,
  "status": "free"
  }
  ],
  "comments": [
  {
  "id": 2,
  "userId": 1,
  "postId": 2,
  "date": "2020-12-15T00:00:00",
  "time": "2020-12-15T00:00:00",
  "text": "neidomus komentaras"
  }
  ]
  }
- put: https://localhost:5001/api/Post
- obj for put: {
  "id": 2,
  "price": 100,
  "seetCount": 4,
  "date": "2020-12-15T00:00:00",
  "info": "idomi informacija",
  "dropoff": "Ismetimo vieta",
  "travelFrom": "Kaunas",
  "travelTo": "Vilnius",
  "pickup": "Stotele",
  "userId": 1,
  "user": null,
  "passengers": [
  {
  "id": 2,
  "passengerId": 1,
  "postId": 2,
  "status": "free"
  }
  ],
  "comments": [
  {
  "id": 2,
  "userId": 1,
  "postId": 2,
  "date": "2020-12-15T00:00:00",
  "text": "neidomus komentaras"
  }
  ]
  }
- delete: https://localhost:5001/api/Post
- obj for delete: { "id": 5 }

Users:

- get: https://localhost:5001/api/user/AllUsers
- get: https://localhost:5001/api/user/UserById?id=1
- get: https://localhost:5001/api/user/GetUserByEmailAndPass?email=email@email.com&password=lol
- post: https://localhost:5001/api/User
- obj for post : {
  "name": "vardenis pavardenis",
  "email": "email@email.com",
  "password": "lol",
  "phoneNumber": "123123",
  "birthDate": "2000-04-16",
  "registrationDate": "2020-12-09",
  "city": "Vilnius",
  "ContactMethod": "emial",
  "UserInfo": "lol not sure",
  "DriverInfo": "kazkas cia turi buti",
  "FacebookLink": "facebook.com",
  "PicturePath": "nuotraukyte",
  "IsDriver": true,
  "AboutDriver": "Vairuoju blaivas",
  "DriverContactMethod": "paukciais",
  "Car": {
  "model": "Volvo",
  "manufacturer": "Blue",
  "year": 2012,
  "color": "blue",
  "picturePath": "test"
  }
  }
- put: https://localhost:5001/api/User
- obj for put: {
  "userId": 6,
  "name": "vardenis pavardenis",
  "email": "email@email.com",
  "password": "lol",
  "phoneNumber": "123123",
  "birthDate": "2000-04-16T00:00:00",
  "registrationDate": "2020-12-09T00:00:00",
  "city": "Vilnius",
  "contactMethod": "emial",
  "userInfo": "lol not sure",
  "driverInfo": "kazkas cia turi buti",
  "facebookLink": "facebook.com",
  "picturePath": "nuotraukyte",
  "isDriver": true,
  "aboutDriver": "Vairuoju blaivas",
  "driverContactMethod": "paukciais",
  "carID": 3,
  "car": null,
  "posts": null,
  "feedbacks": null
  }
- delete: https://localhost:5001/api/User
- obj for delete: { "userId": 5 }

Feedback:

- get: https://localhost:5001/api/Feedback/AllFeedbacks,
- post: https://localhost:5001/api/Feedback
  obj for post: {
  "senderId": 1,
  "receiverId": 2,
  "CreateDate": "2020-12-09",
  "rating": "10/10",
  "Text": "lool",
  "ReceiverIsDriver": false
  }
- put: https://localhost:5001/api/Feedback
  obj for put: {
  "id": 1,
  "senderId": 1,
  "receiverId": 2,
  "createDate": "2020-12-09T00:00:00",
  "rating": "10/10",
  "text": "lool",
  "receiverIsDriver": false
  }
- delete: https://localhost:5001/api/Feedback
  obj for delete: { "userId": 5 }

Reservation:

- get: https://localhost:5001/api/reservation/AllReservations
- post: https://localhost:5001/api/reservation/
  obj for post: {
  "passengerId": 1,
  "postId": 2,
  "status": "free"
  },

  - put: https://localhost:5001/api/reservation/
    obj for put: {
    "id": 1,
    "passengerId": 1,
    "postId": 2,
    "status": "free"
    }
  - delete: https://localhost:5001/api/reservation/
    obj for delete: { "id": 5 }

    Comments:

- get: https://localhost:5001/api/comment/AllComments
- post: https://localhost:5001/api/comment/
  obj for post: {
  "userId": 1,
  "postId": 2,
  "date": "2020-12-15 00:00:00.0000000",
  "text": "neidomus komentaras"
  },
  - put: https://localhost:5001/api/comment/
    obj for put: {
    "id": 1,
    "userId": 1,
    "postId": 2,
    "date": "2020-12-15 00:00:00.0000000",
    "text": "neidomus komentaras"
    }
  - delete: https://localhost:5001/api/comment/
    obj for delete: { "id": 5 }
