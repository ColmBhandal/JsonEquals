# JsonEquals

Convenience Methods for Object Equality Via JSON Serialization.

Comparing objects via JSON serialization has the advantage that you don't have to repeatedly define equals methods for custom objects e.g. when writing tests for those objects. Instead, the idea is just to serialize to JSON and then compare the strings. It may not be the fastest way to compare objects, but for small objects e.g. used in unit tests, it's ideal and saves you time having to write out separate custom equality methods per class. 

# References

 * Idea loosely based on [this article](https://beribey.medium.com/deep-compare-2-object-in-c-ff1191346736).
 * This library is really just a convenience wrapper for the powerful library of [Json.NET - Newtonsoft](https://www.newtonsoft.com/json)
