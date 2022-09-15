Imports FluentValidation
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports vb.Models
Imports SdkVisualBasic.vb.Models

Namespace vb.Validators
    Public Class D3DSValidator
        Inherits AbstractValidator(Of D3DSData)

        Public Sub New()
            RuleFor(Function(d3dsData) d3dsData.email).MinimumLength(1).MaximumLength(100)
            RuleFor(Function(d3dsData) d3dsData.phone).MinimumLength(1).MaximumLength(20)
            RuleFor(Function(d3dsData) d3dsData.address).MinimumLength(1).MaximumLength(60)
            RuleFor(Function(d3dsData) d3dsData.city).MinimumLength(1).MaximumLength(30)
            RuleFor(Function(d3dsData) d3dsData.state).MinimumLength(2).MaximumLength(2)
            RuleFor(Function(d3dsData) d3dsData.zipCode).MinimumLength(1).MaximumLength(10)
            RuleFor(Function(d3dsData) d3dsData.countryCode).MinimumLength(3).MaximumLength(3)
        End Sub
    End Class
End Namespace
