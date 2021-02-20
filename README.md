# API Worker

<p align="center">
  <img src="https://github.com/VsIG-official/API-Worker/blob/master/API-Worker.png" data-canonical-src="https://github.com/VsIG-official/API-Worker/blob/master/API-Worker.png" width="750" height="200" />
</p>

## Table of Contents

- [Description](#description)
- [Badges](#badges)
- [Example](#example)
- [Requirements](#requirements)
- [Contributing](#contributing)
- [License](#license)

### Description

Simple C# console application, which uses these API's:
  - [Age by Name](https://agify.io/)
  - [Gender by Name](https://genderize.io/)
  - [Jokes](https://github.com/15Dkatz/official_joke_api)
  - [Activities](https://www.boredapi.com/api/activity)

## Badges

> [![Language](https://img.shields.io/badge/Language-C%23-blueviolet)](https://en.wikipedia.org/wiki/C_Sharp_(programming_language))
> [![Codacy Badge](https://api.codacy.com/project/badge/Grade/ea2f529552984318bd4aa8d45186de36)](https://app.codacy.com/gh/VsIG-official/API-Worker?utm_source=github.com&utm_medium=referral&utm_content=VsIG-official/API-Worker&utm_campaign=Badge_Grade)
> [![Theme](https://img.shields.io/badge/Theme-API-blue?style=flat-square)](https://en.wikipedia.org/wiki/API)
> [![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

---

## Example

```csharp
/// <summary>
	/// Class for Api Client
	/// </summary>
	public static class ApiHelper
	{
		// Create static, 'cause We need one client per application
		public static HttpClient ApiClient { get; set; }

		/// <summary>
		/// Initializes API client
		/// </summary>
		public static void Initialize()
		{
			ApiClient = new HttpClient
			{
				// a lot of adresses will begin with the same string,
				// so We can put the beginning here
				// but won't, because We need more than one adress
				/*
				BaseAddress = new Uri("http://somesite.com/")
				*/
			};
			ApiClient.DefaultRequestHeaders.Accept.Clear();
			// give Us json, not webpage or etc.
			ApiClient.DefaultRequestHeaders.Accept.Add(new
				MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
```

---

## Requirements

Target Framework: .NET Framework 4.8

---

## Contributing

> To get started...

### Step 1

- 🍴 Fork this repo!

### Step 2

- **HACK AWAY!** 🔨🔨🔨

---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2021 © <a href="https://github.com/VsIG-official" target="_blank">VsIG</a>.
