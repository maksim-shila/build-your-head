# Build Your Head

## Local Development
    Raise db: ~/build-your-head/ docker-compose up db
    Run API: open BuildYourHead.sln with VS and run
    Run front: ~/build-your-head/build-your-head-ui/ yarn dev

## Useful Commands

### EF:
    dotnet-ef --startup-project ../BuildYourHead.Api/ migrations add InitialCreate


## TODO:
    - [back] Implement users storage
    - [front] fix too long blob (compress images on upload)
    - [front] add error handling (notifications)
    - [front] set up formatter