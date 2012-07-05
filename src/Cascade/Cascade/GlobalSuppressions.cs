// Supress warning for too few types in a namespace, as data related extension methods shall only be usable when needed.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Cascade.Data")]
// At the moment not planned to sign the cascade assembly. If one needs to store the Cascade in GAC, Cascade has to be compiled with own key and installed to the GAC.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]