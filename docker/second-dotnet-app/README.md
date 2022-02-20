
Пример docker-образа .net консольного приложения. 
Особенностью данного образа в том, что можем передать переменные окружения в настройки приложения.

1. Создать консольное приложение .NET FRAMEWORK
   dotnet new console

2. Добавить пакеты  Microsoft.Extensions.Hosting
   dotnet add package Microsoft.Extensions.Hosting --version 6.0.1

3. Создать файл с настройками appsettings.json
4. Отредактировать файл *.csproj
   Добавивь строчки

  <ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>

5. Создания docker-образа
docker build -t tkalenko/docker-learn-dotnet:v2.0 .


6. Запуск контейнера
docker run -it tkalenko/docker-learn-dotnet:v2.0 .

7. Запуск контейнер с переданной переменной окружения
docker run -it -e MESSAGE__BYE='I love you' tkalenko/docker-learn-dotnet:v2.0 .

