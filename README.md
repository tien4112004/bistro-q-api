# bistro-q-api

## Add migrations

```bash
dotnet ef migrations add --project BistroQ.Infrastructure --startup-project BistroQ.API --context BistroQ.Infrastructure.Data.BistroQContext --configuration Debug --verbose AutoCreateOrderIdAndOrderItemId --output-dir Migrations
```

## Apply migrations

```bash
dotnet ef database update --project BistroQ.Infrastructure --startup-project BistroQ.API --context BistroQ.Infrastructure.Data.BistroQContext --verbose 
```