﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationTest.Services.GoodreadsServiceTest {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TestData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ApplicationTest.Services.GoodreadsServiceTest.TestData", typeof(TestData).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;GoodreadsResponse&gt;
        ///    &lt;Request&gt;
        ///        &lt;authentication&gt;true&lt;/authentication&gt;
        ///        &lt;key&gt;
        ///            &lt;![CDATA[s1gIFUeJ1FOsqBQc3kC9pw]]&gt;
        ///        &lt;/key&gt;
        ///        &lt;method&gt;
        ///            &lt;![CDATA[book_show]]&gt;
        ///        &lt;/method&gt;
        ///    &lt;/Request&gt;
        ///    &lt;book&gt;
        ///        &lt;id&gt;11588&lt;/id&gt;
        ///        &lt;title&gt;The Shining&lt;/title&gt;
        ///        &lt;isbn&gt;
        ///            &lt;![CDATA[0450040186]]&gt;
        ///        &lt;/isbn&gt;
        ///        &lt;isbn13&gt;
        ///            &lt;![CDATA[9780450040184]]&gt;
        ///        &lt;/isbn13&gt;
        ///      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ValidGetBookResponse {
            get {
                return ResourceManager.GetString("ValidGetBookResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;GoodreadsResponse&gt;
        ///  &lt;Request&gt;
        ///    &lt;authentication&gt;true&lt;/authentication&gt;
        ///      &lt;key&gt;&lt;![CDATA[s1gIFUeJ1FOsqBQc3kC9pw]]&gt;&lt;/key&gt;
        ///    &lt;method&gt;&lt;![CDATA[search_index]]&gt;&lt;/method&gt;
        ///  &lt;/Request&gt;
        ///  &lt;search&gt;
        ///  &lt;query&gt;&lt;![CDATA[King]]&gt;&lt;/query&gt;
        ///    &lt;results-start&gt;1&lt;/results-start&gt;
        ///    &lt;results-end&gt;2&lt;/results-end&gt;
        ///    &lt;total-results&gt;162927&lt;/total-results&gt;
        ///    &lt;source&gt;Goodreads&lt;/source&gt;
        ///    &lt;query-time-seconds&gt;0.07&lt;/query-time-seconds&gt;
        ///    &lt;results&gt;
        ///        &lt;work&gt;
        ///  &lt;id [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ValidSearchBooksResponse {
            get {
                return ResourceManager.GetString("ValidSearchBooksResponse", resourceCulture);
            }
        }
    }
}