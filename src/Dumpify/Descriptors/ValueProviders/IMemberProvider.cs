﻿using Dumpify.Config;

namespace Dumpify.Descriptors.ValueProviders;

public interface IMemberProvider : IEquatable<IMemberProvider>
{
    IEnumerable<IValueProvider> GetMembers(Type type);
}
