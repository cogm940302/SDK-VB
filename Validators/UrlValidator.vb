Imports FluentValidation
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports vb.Models
Imports SdkVisualBasic.vb.Models

Namespace vb.Validators
    Friend Class UrlValidator
        Inherits AbstractValidator(Of UrlData)

        Public Sub New()
            RuleFor(Function(urlData) urlData.reference).NotNull().MinimumLength(1).MaximumLength(100)
            RuleFor(Function(urlData) urlData.amount).GreaterThan(0)
            RuleFor(Function(urlData) urlData.moneda).NotNull()
            RuleFor(Function(urlData) urlData.omitNotification).GreaterThanOrEqualTo(0)
            RuleFor(Function(urlData) urlData.promotions).MinimumLength(1).MaximumLength(40)
            RuleFor(Function(urlData) urlData.stEmail).GreaterThanOrEqualTo(0)
        End Sub
    End Class
End Namespace
