
using System;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class FastAttribute : Attribute{ }

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class NeutralAttribute : Attribute{ }

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class SlowAttribute : Attribute{ }

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class OnLandAttribute : Attribute{ }

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class MidAttribute : Attribute{ }

