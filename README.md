# Results-Class
An efficient way to return Results with value.

### Usage

C#
```c#
public Results<MyClass> MyStuff()
{
	try
	{
		MyClass obj = GetMyStuffFromSomewhere();
		return Results<MyClass>.Success(obj);
	}
	catch (Exception ex)
	{
		return Results<MyClass>.Error(ex.Message);
	}
}
```

Typescript
```Javascript
import { IResults } from './IResults';
const getMyStuff = () => {
	fetch('api/stuff/5').Then(x => x.json()).Then((x: IResults<IMyStuff>) => {
		if (x.isSuccess) {
			setMyStuff(x.value);
		}
		else {
			setErrorMessage(x.message);
		}
	});
}
```