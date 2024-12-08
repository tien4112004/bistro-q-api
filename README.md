# bistro-q-api

## Add migrations

```bash
dotnet ef migrations add --project BistroQ.Infrastructure --startup-project BistroQ.API --context BistroQ.Infrastructure.Data.BistroQContext --configuration Debug --verbose AutoCreateOrderIdAndOrderItemId --output-dir Migrations
```

## Apply migrations

```bash
dotnet ef database update --project BistroQ.Infrastructure --startup-project BistroQ.API --context BistroQ.Infrastructure.Data.BistroQContext --verbose 
```

## Run the test

### Using `dotnet` CLI

```bash
dotnet test
```

### Using Visual Studio/Jetbrains Rider

Run the test using the Test Explorer/Test Runner in the IDE.
