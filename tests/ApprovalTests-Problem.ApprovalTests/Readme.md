
# ERROR

Test method ApprovalTests_Problem.ApprovalTests.SimpleTest.TestList threw exception: 
System.Exception: 
ApprovalTests is not detecting the proper source path

This is probably because you're missing the following
line in your .csproj file:
	  <DebugType>full</DebugType>
in the
<Project>
  <PropertyGroup>
element.

Solution:
a) Add <DebugType>full</DebugType> to your .csproj file.
b) OR Build->Advanced->DebugInfo to Full
    at ApprovalTests.Namers.StackTraceParsers.StackTraceParser.get_SourcePath() in C:\projects\approvaltests-net\src\ApprovalTests\Namers\StackTraceParsers\StackTraceParser.cs:line 80
   at ApprovalTests.Namers.UnitTestFrameworkNamer.get_SourcePath() in C:\projects\approvaltests-net\src\ApprovalTests\Namers\UnitTestFrameworkNamer.cs:line 28
   at ApprovalTests.Approvers.FileApprover.Approve() in C:\projects\approvaltests-net\src\ApprovalTests\Approvers\FileApprover.cs:line 27
   at ApprovalTests.Core.Approver.Verify(IApprovalApprover approver, IApprovalFailureReporter reporter) in C:\projects\approvaltests-net\src\ApprovalTests\Core\Approver.cs:line 7
   at ApprovalTests.Approvals.Verify(IApprovalApprover approver, IApprovalFailureReporter reporter) in C:\projects\approvaltests-net\src\ApprovalTests\Approvals.cs:line 71
   at ApprovalTests.Approvals.Verify(IApprovalWriter writer, IApprovalNamer namer, IApprovalFailureReporter reporter) in C:\projects\approvaltests-net\src\ApprovalTests\Approvals.cs:line 52
   at ApprovalTests.Approvals.Verify(IApprovalWriter writer) in C:\projects\approvaltests-net\src\ApprovalTests\Approvals.cs:line 124
   at ApprovalTests.Approvals.VerifyWithExtension(String text, String fileExtensionWithDot, Func`2 scrubber) in C:\projects\approvaltests-net\src\ApprovalTests\Approvals.cs:line 189
   at ApprovalTests.Approvals.Verify(String text, Func`2 scrubber) in C:\projects\approvaltests-net\src\ApprovalTests\Approvals.cs:line 176
   at ApprovalTests.Approvals.VerifyAll[T](IEnumerable`1 enumerable, String label) in C:\projects\approvaltests-net\src\ApprovalTests\Approvals.cs:line 213
   at ApprovalTests_Problem.ApprovalTests.SimpleTest.TestList() in D:\Work\ApprovalTests-Problem\tests\ApprovalTests-Problem.ApprovalTests\TestingLibrary.cs:line 20