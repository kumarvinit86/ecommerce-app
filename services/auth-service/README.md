

```plaintext
auth-service/
│
├── AuthService.API                 --> API layer (Controllers)
├── AuthService.Application        --> CQRS, Validators, DTOs
├── AuthService.Domain             --> Core Models & Enums
├── AuthService.Infrastructure     --> SQL, Dapper, EF, Identity, Hashing, JWT
├── AuthService.Tests              --> xUnit test project
├── AuthService.Contracts          --> Shared DTOs (for other services)
└── dockerfile
```