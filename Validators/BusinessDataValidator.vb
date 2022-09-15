Imports FluentValidation
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports vb.Models
Imports SdkVisualBasic.vb.Models

Namespace vb.Validators
    Public Class BusinessDataValidator
        Inherits AbstractValidator(Of BusinessData)

        Public Sub New()
            RuleFor(Function(businessData) businessData.idBranch).NotNull().MinimumLength(1).MaximumLength(11)
            RuleFor(Function(businessData) businessData.idCompany).NotNull().MinimumLength(4).MaximumLength(4)
            RuleFor(Function(businessData) businessData.user).NotNull().MinimumLength(9).MaximumLength(11)
            RuleFor(Function(businessData) businessData.user).NotNull().MinimumLength(1).MaximumLength(80)
        End Sub
    End Class
End Namespace
