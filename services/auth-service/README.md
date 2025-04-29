
```plaintext
auth-service/
│
├── AuthService.API                 --> API layer (Controllers),Validators, DTOs
├── AuthService.Application        --> CQRS & Orchastration
├── AuthService.Domain             --> Core Models & Enums
├── AuthService.Infrastructure     --> SQL, Dapper, EF, Identity, Hashing, JWT
├── AuthService.Tests              --> xUnit test project
├── AuthService.Contracts          --> Inbound & outbound port contracts
└── dockerfile
```