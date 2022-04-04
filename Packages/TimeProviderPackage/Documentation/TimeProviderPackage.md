# TimeProvider official documentation
TimeProvider package is extremely easy to use! Just put next code to your project and get it running!

## BootStrap
You can start from adding this code. (Dont forget to reference main assembly `TimeProviderAssembly` in order to make it visible for you)
### Simple sample

Just create a new instance of `TimeService` like 

            ITimeService _timeService = new TimeService();

### Zenject sample

Find your installer and ad following code

        Container.Bind<ITimeService>().To<TimeService>().AsSingle();

In the result it should look like this

        public override void InstallBindings()
        {
            //some your other bindings here
            // .....
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
        }

And that`s all, now you can simply bind and use it!

## How to use
Use `DateTime GetTime(ProviderType type);`
There are several `ProviderType` type options:\
`DateTime` - this type using simple `DateTime.Now` field to get current time\
`Ntc` - this type getting current time from `time.windows.com`

For more info about executing code please refer to `Provider` directory in package.

## Custom services and providers
Also you can add your own time service and providers if you need!\
Just add your own interface inherited from `IGenericTimeService<T>` where T is enum defining provider types.
So you need a `enum` to represent your custom types. Finaly create your class to inherit from `GenericTimeService<T>` (where `T` is your `enum`).
And basically you are good to go!

Dont forget to add your providers to 
            
            protected Dictionary<T, TimeProvider> _timeProviders;

You can use base code to get `DateTime` value that is ready for your use in base class

    public virtual DateTime GetTime(T type)
        {
            if (_timeProviders.TryGetValue(type, out var timeProvider))
            {
                return timeProvider.GetTime();
            }
            else
            {
                throw new ArgumentException($"There is no '{type}' provider!");
            }
        }

Or feel free to override it!

