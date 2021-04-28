# json-to-json-map
Get any json response from API and generate a new json string from a simple dictionary&lt;string, string> map

Fake data from:
https://jsonplaceholder.typicode.com

## How it works

Use a array response or single response to JObject
```c#
var json = await result.Content.ReadAsAsync<JObject[]>();

var json = await result.Content.ReadAsAsync<JObject>();
```

Execute a method with mapping columns:
```c#
var mapped = JMap.Bind(json, new Dictionary<string, string>
{
    {"userId", "userIdMap"},
    {"title", "titleMap"}
});
```

## Results

#### Original
```json
{
  "userId": 1,
  "id": 1,
  "title": "delectus aut autem",
  "completed": false
}
```

#### To Mapped
```json
{
  "userIdMap": 1,
  "titleMap": "delectus aut autem"
}
```
