Imports FluentValidation
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports vb.Models
Imports SdkVisualBasic.vb.Models


Namespace vb.Validators
    Public Class DatosAdicionalesValidator
        Inherits AbstractValidator(Of DatosAdicionalesData.DataItem)

        Public Sub New()
            RuleFor(Function(dataItem) dataItem.id).GreaterThan(-1)
            RuleFor(Function(dataItem) dataItem.label).NotNull().MinimumLength(1).MaximumLength(60)
            RuleFor(Function(dataItem) dataItem.value).NotNull().MinimumLength(1).MaximumLength(100)
        End Sub
    End Class
End Namespace
