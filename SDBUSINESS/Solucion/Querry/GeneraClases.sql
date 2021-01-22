
GO

/****** Object:  StoredProcedure [dbo].[GeneraCodigoClase]    Script Date: 2/19/2015 9:50:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GeneraCodigoClase](@Tabla varchar(250) ,@nombre as varchar(250))
as
begin 
	Declare @id    int
  Declare @Campo  varchar(250)
  Declare @Tipo   varchar(250)



	Select @id = id  
	from sysobjects 
	Where XType = 'U'
	and   name  =  @Tabla
	

------------------------------------ variables ----------------------------------
  if @nombre <> '' begin
    print 'Public Class ' + @nombre
  end
  else begin
    print 'Public Class T' + @Tabla
  end
	PRINT 'Inherits TBaseClassManager'
	declare  lista Cursor for 
		Select C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'integer'
			when  'char'  then 'Char'
			when  'datetime'  then 'Datetime'
			when  'decimal'  then 'Double'
			when  'float'  then  'Double'
			when  'int'  then 'integer'
			when  'money'  then 'Double'
			when  'numeric' then 
                        case 
                          when C.scale <> 0 then 'Double'
                          else 'Int64'
                        end
			when  'real'  then 'Double'
			when  'smalldatetime'  then 'Date'
			when  'smallint'  then 'integer'
			when  'smallmoney'  then 'Double'
			when  'varchar'     then 'String'
			when  'nvarchar'    then 'String'
      when  'xml'         then 'String'
      when  'bigint' then 'long'
			else  T.name
		end AS Tipo	
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder

	OPEN Lista
	print ' '
	print '#Region "Definicion Variables Locales"'
	print ' '

	FETCH NEXT FROM Lista INTO @Campo, @tIPO
	WHILE @@FETCH_STATUS = 0 BEGIN
		print 'Private _' + @Campo + ' as ' + @Tipo
		FETCH NEXT FROM Lista INTO @Campo, @tIPO
	END
	CLOSE Lista
	DEALLOCATE Lista
  print 'Private _Data As DataSet'
	print ' '
	PRINT '#End Region'
	PRINT ''

------------------------------------ propiedades --------------------------------
  print '#Region "Definicion de propiedades"'
  print ''
	declare  lista Cursor for 
		Select C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'integer'
			when  'char'  then 'Char'
			when  'datetime'  then 'Datetime'
			when  'decimal'  then 'Double'
			when  'float'  then  'Double'
			when  'int'  then 'integer'
			when  'money'  then 'Double'
			when  'numeric' then 
                        case 
                          when C.scale <> 0 then 'Double'
                          else 'Int64'
                        end
			when  'real'  then 'Double'
			when  'smalldatetime'  then 'Date'
			when  'smallint'  then 'integer'
			when  'smallmoney'  then 'Double'
			when  'varchar'  then 'String'
			when  'nvarchar'  then 'String'
      when  'xml' then 'string'
      when  'bigint' then 'long'
			else  T.name
		end AS Tipo	
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder

	OPEN Lista
	FETCH NEXT FROM Lista INTO @Campo, @tIPO
	WHILE @@FETCH_STATUS = 0 BEGIN

			print 'Public Property '  + @Campo + '() as ' + @Tipo
			print '    Get'
			print '       Return _' + @Campo
			print '    End Get'
			print '    Set(ByVal Value As ' + @Tipo + ')'
			print '       _' + @Campo +' = Value'
			print '	   End Set'
    		print 'End Property'

		FETCH NEXT FROM Lista INTO @Campo, @tIPO
	END
	CLOSE Lista
	DEALLOCATE Lista


  print 'Public ReadOnly Property Data() As DataSet'
  print 'Get'
  print '   Return _Data'
  print 'End Get'
  print 'End Property'
  print 'Public ReadOnly Property RowsAffected() As Long'
  print '   Get'
  print '       Return Cn.RowsAffected'
  print 'End Get'
  print 'End Property'
  print ''
	print ''
	print '#End Region'


------------------------------------ constructores ------------------------------

  print '#Region "Constructores"'
  print 'Public Sub New(pEmp_Id as integer)'
  print ' MyBase.New()'
  print ' Inicializa()'
  print ' _Emp_Id = pEmp_Id'
  print 'End Sub'
  print 'Public Sub New(pEmp_Id as integer, ByVal pCnStr As String)'
  print ' MyBase.New(pCnStr)'
  print ' Inicializa()'
  print ' _Emp_Id = pEmp_Id'
  print 'End Sub'
  print '#End Region'

------------------------------------ metodos privados ---------------------------

  print '#Region "Metodos Privados"'
  print 'Private Sub Inicializa'  
	declare  lista Cursor for 
		Select C.NAME Campo, Case  t.NAME  
			when  'bit'  then '0'
			when  'char'  then '""'
			when  'datetime'  then 'CDATE("1900/01/01")'
			when  'decimal'  then '0.00'
			when  'float'  then  '0.00'
			when  'int'  then '0'
			when  'money'  then '0.00'
			when  'numeric' then 
                        case 
                          when C.scale <> 0 then '0.00'
                          else '0'
                        end
			when  'real'  then '0.00'
			when  'smalldatetime'  then 'CDATE("1900/01/01")'
			when  'smallint'  then '0'
			when  'smallmoney'  then '0'
			when  'varchar'  then '""'
			when  'nvarchar'  then '""'
      when  'xml' then '""'
      when  'bigint' then '0'
			else  T.name
		end AS Tipo	
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder
	OPEN Lista
	FETCH NEXT FROM Lista INTO @Campo, @tIPO
	WHILE @@FETCH_STATUS = 0 BEGIN		
    PRINT  '             _' + @Campo +'= ' + @Tipo
		FETCH NEXT FROM Lista INTO @Campo, @tIPO
	END
	CLOSE Lista
	DEALLOCATE Lista
	print '_Data = New Dataset'
  print 'End Sub'
  print '#End Region'


------------------------------------ metodos publicos ---------------------------
	PRINT '#Region "Definicion metodos publicos"'
	----------------------------------insert
	print '    Public Overrides Function Insert() As string'
  print '        Dim Query As String = ""'
  print '        Try'
  print '            Cn.Open()'
  print ''
  print '            Cn.BeginTransaction()'
  print ''
	exec GeneraCodigoClaseInsert @id, @Tabla
  print ''
  print '            Cn.Ejecutar(Query)'
  print ''
  print '            Cn.CommitTransaction()'
  print ''
  print '            Return ""'
  print '        Catch ex As Exception'
  print '            Cn.RollBackTransaction()'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'

	-------------------------DELETE
	print '    Public Overrides Function Delete() As String'
	print '        Dim Query As String = ""'
	print '        Try'
	print '            Cn.Open()'
	print ''
	print '            Cn.BeginTransaction()'
	print ''
	print '        query =  "Delete '+ @Tabla +'" & _ '
	exec GeneraCodigoClaseWhere @id, @Tabla
	print ''
	print '            Cn.Ejecutar(Query)'
	print ''
	print '            Cn.CommitTransaction()'
	print ''
	print '            Return ""'
	print '        Catch ex As Exception'
	print '            Cn.RollBackTransaction()'
	print '            Return ex.Message'
	print '        Finally'
	print '            Cn.Close()'
	print '        End Try'
	print '    End Function'

  -------------------------MODIFY
	print '    Public Overrides Function Modify() As String'
	print '        Dim Query As String = ""'
	print '        Try'
	print '            Cn.Open()'
	print ''
	print '            Cn.BeginTransaction()'
	print ''
	exec GeneraCodigoClaseUpdate @id, @Tabla
	exec GeneraCodigoClaseWhere  @id, @Tabla
	print ''
	print '            Cn.Ejecutar(Query)'
	print ''
	print '            Cn.CommitTransaction()'
	print ''
	print '            Return ""'
	print '        Catch ex As Exception'
	print '            Cn.RollBackTransaction()'
	print '            Return ex.Message'
	print '        Finally'
	print '            Cn.Close()'
	print '        End Try'
	print '    End Function'


  -------------------------LISTKEY
	print '    Public Overrides Function ListKey() As String'
	print '        Dim Query As String'
	print '        Dim Tabla As DataTable'
	print '        Try'
	print '            Cn.Open()'
	print ''
	print '            Query = "select * From ' + @Tabla + '" & _'
 exec GeneraCodigoClaseWhere  @id, @Tabla
	print ''
	print '            Tabla = Cn.Seleccionar(Query).Copy'
	print ''
	print '            If Not Tabla Is Nothing AndAlso Tabla.Rows.Count > 0 Then'
	declare  lista Cursor for 
		Select C.NAME Campo
		from   syscolumns C 
		where C.id =  @id
		order by c.colorder
	OPEN Lista
	FETCH NEXT FROM Lista INTO @Campo
	WHILE @@FETCH_STATUS = 0 BEGIN		
		PRINT  '               _' + @Campo + ' = Tabla.Rows(0).Item("' + @Campo+ '")'
		FETCH NEXT FROM Lista INTO @Campo
	END
	CLOSE Lista
	DEALLOCATE Lista
	print '            End If'
	print ''
	print '            Return ""'
	print ''
  print '      Catch ex As Exception'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'

  -------------------------LIST
  print '    Public Overrides Function List() As String'
  print '        Dim Query As String'
  print '        Dim Tabla As DataTable'
  print '        Try'
  print '            Cn.Open()'
  print ''
	print '            Query = "select * From ' + @Tabla + '"'
  print ''
  print '            Tabla = Cn.Seleccionar(Query).Copy'
  print ''
  print '            If _Data.Tables.Contains(Tabla.TableName) Then'
  print '                _Data.Tables.Remove(Tabla.TableName)'
  print '            End If'
  print ''
  print '            _Data.Tables.Add(Tabla)'
  print ''
  print '            Return ""'
  print ''
  print '        Catch ex As Exception'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'
  
    -------------------------LOAD
  print '    Public Overrides Function LoadComboBox(pCombo As System.Windows.Forms.ComboBox) As String'
  print '        Dim Query As String'
  print '        Dim Tabla As DataTable'
  print '        Try'
  print '            Cn.Open()'
  print ''
	print '            Query = "select ' + @Tabla + '_Id as Numero, Nombre From ' + @Tabla + '"'
  print ''
  print '            Tabla = Cn.Seleccionar(Query).Copy'
  print ''
  print '            If not Tabla is nothing Then'
  print '            pCombo.DataSource = Nothing'
  print '            pCombo.DataSource = Tabla'
  print '            pCombo.DisplayMember = "Nombre"'
  print '            pCombo.ValueMember = "Numero"'
  print '            End If'
  print ''
  print '            Return ""'
  print ''
  print '        Catch ex As Exception'
  print '            Return ex.Message'
  print '        Finally'
  print '            Cn.Close()'
  print '        End Try'
  print '    End Function'



  print '#End Region'

  print 'End Class'
end

GO

/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseInsert]    Script Date: 2/19/2015 9:50:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GeneraCodigoClaseInsert] (@id as int, @Table varchar (250) ) as
begin

	Declare @Campo   varchar(250)
	Declare @Tipo    varchar(250)
	Declare @Fields  varchar(5000)
	Declare @Values  varchar(5000)
	Declare @Enter   varchar(50)
	Declare @Order   int
	Declare @Primero   int
	Declare @ContEnter int
	declare  lista Cursor for

		Select distinct C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'System.Boolean'
			when  'char'  then 'System.String'
			when  'datetime'  then 'System.DateTime'
			when  'decimal'  then 'System.Double'
			when  'float'  then  'System.Double'
			when  'int'  then 'System.Int32'
			when  'money'  then 'System.Double'
			when  'numeric'  then 'System.Double'
			when  'real'  then 'System.Double'
			when  'smalldatetime'  then 'System.DateTime'
			when  'smallint'  then 'System.Int32'
			when  'smallmoney'  then 'System.Double'
			when  'varchar'  then 'System.String'
			when  'nvarchar'  then 'System.String'
			when  'xml'  then 'System.String'
			when  'bigint'  then 'System.Int64'
			else  T.name
		end AS Tipo	, c.colorder
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		order by c.colorder

	OPEN Lista

	Set @Fields  = ''
	Set @Values  = ''
	Set @Primero = 1 
	set @ContEnter = 0 
	set @Enter = '   & _' +Char(13) + '       '

	FETCH NEXT FROM Lista INTO @Campo, @tIPO , @Order
	WHILE @@FETCH_STATUS = 0 BEGIN
		if @Primero = 1 begin
			Set @Fields = '" Insert into '+ @Table +'( ' + @Campo
			set @Primero	= 0 
			if @tIPO <> 'System.String' begin
			   Set @Values = '       " Values ( " & _' + @Campo + '.ToString()'
			end
			else begin
				Set @Values = '       " Values ( ' + char(39) + '"& _' + @Campo +  ' & "' + Char(39) + '"'
			end 
		end 
		else begin
			Set @Fields = @Fields +' , ' + @Campo
			if @tIPO <> 'System.String' begin
				if @Tipo <> 'System.DateTime' begin
					if @ContEnter = 1 begin
					    Set @Values = @Values +' & "," & _' + @Campo + '.ToString()'
					end
					else begin
					    Set @Values = @Values +'"," & _' + @Campo + '.ToString()'
					end
				end 
				else begin
					if @ContEnter = 1 begin
					    Set @Values = @Values +' & ",'+ char(39) + '" & Format(_' + @Campo +  ',"yyyyMMdd HH:mm:ss") & "' + Char(39) + '"'
					end
					else begin
						Set @Values = @Values +'",'+ char(39) + '" & Format(_' + @Campo +  ',"yyyyMMdd HH:mm:ss") & "' + Char(39) + '"'
					end
				end 
			end
			else begin
					if @ContEnter = 1 begin
						Set @Values = @Values +' & ",'+ char(39) + '" & _' + @Campo +  ' & "' + Char(39) + '"'
					end
					else begin
						Set @Values = @Values +'",'+ char(39) + '" & _' + @Campo +  ' & "' + Char(39) + '"'
					end
			end 
		end
		set @ContEnter = @ContEnter + 1 
		if @ContEnter = 2 begin
			set @ContEnter = 0 
			Set @Values = @Values + @Enter
			Set @Fields = @Fields + '"' +@Enter+ '"'
		end 
		FETCH NEXT FROM Lista INTO @Campo, @tIPO, @Order
	END
	CLOSE Lista
	DEALLOCATE Lista
	print 'query = ' + @Fields + ' )" & _ ' 
	print @Values + ' & ")"'
end

GO

/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseUpdate]    Script Date: 2/19/2015 9:50:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GeneraCodigoClaseUpdate] (@id as int, @Table varchar (250) ) as
begin

	Declare @Campo   varchar(250)
	Declare @Tipo    varchar(250)
	Declare @Fields  varchar(8000)
	Declare @Values  varchar(8000)
	Declare @Order   int
	Declare @Primero   int
	declare  lista Cursor for

		Select distinct C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'System.Boolean'
			when  'char'  then 'System.String'
			when  'datetime'  then 'System.DateTime'
			when  'decimal'  then 'System.Double'
			when  'float'  then  'System.Double'
			when  'int'  then 'System.Int32'
			when  'money'  then 'System.Double'
			when  'numeric'  then 'System.Double'
			when  'real'  then 'System.Double'
			when  'smalldatetime'  then 'System.DateTime'
			when  'smallint'  then 'System.Int32'
			when  'smallmoney'  then 'System.Double'
			when  'varchar'  then 'System.String'
			when  'nvarchar'  then 'System.String'
			else  T.name
		end AS Tipo	, c.colorder
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		AND   C.NAME NOT IN (Select C.Name
					from   syscolumns C ,    SysIndexes I , SysIndexkeys K 
					where C.id =  @id
					and   I.id = C.id
					and   I.name like 'PK_%'
					and   K.id = C.id
					and   K.indid = I.indid
					and   K.Colid = C.Colid)
		order by c.colorder

	OPEN Lista

	Set @Fields  = ''
	Set @Values  = ''
	Set @Primero = 1 

	FETCH NEXT FROM Lista INTO @Campo, @tIPO , @Order
	WHILE @@FETCH_STATUS = 0 BEGIN
			
		if @Primero = 1 begin
			set @Primero	= 0 
			if @tIPO <> 'System.String' begin
			   Set @Fields = '       " SET    ' + @Campo + '=" & _'+ @Campo + '.ToString() '
			end
			else begin
			   Set @Fields = '       " SET   ' + @Campo + '=' +char(39)+'" & _'+ @Campo +'  &"' +char(39) +' "'
			end 
		end 
		else begin
			if @tIPO <> 'System.String' begin
				if @Tipo <> 'System.DateTime' begin
					Set @Fields = @Fields + ' & "," & _' +char(13) + '           " '+ @Campo + '=" & _'+ @Campo + ''
				end 
				else begin
					Set @Fields = @Fields + ' & "," & _' +char(13) + '           " '+ @Campo + '=' + char(39) + '" & Format(_'+ @Campo  +',"yyyyMMdd HH:mm:ss") &"' +char(39) +'"'
				end 
			end
			else begin
				Set @Fields = @Fields + ' & "," & _' +char(13) + '           " '+ @Campo + '='+ char(39)+'" & _'+ @Campo +' &"' +char(39) +'"'
			end 
		end
		
		FETCH NEXT FROM Lista INTO @Campo, @tIPO, @Order
	END
	CLOSE Lista
	DEALLOCATE Lista

	print  ' query = " Update dbo.' + @Table + ' " & _ ' 
	print  '    ' + @Fields + ' & _ '
end

GO

/****** Object:  StoredProcedure [dbo].[GeneraCodigoClaseWhere]    Script Date: 2/19/2015 9:50:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GeneraCodigoClaseWhere] (@id as int, @Table varchar (250) ) as
begin

	Declare @Campo   varchar(250)
	Declare @Tipo    varchar(250)
	Declare @Fields  varchar(2000)
	Declare @Values  varchar(2000)
	Declare @Order   int
	Declare @Primero   int
	declare  lista Cursor for

		Select distinct C.NAME Campo, Case  t.NAME  
			when  'bit'  then 'System.Boolean'
			when  'char'  then 'System.String'
			when  'datetime'  then 'System.DateTime'
			when  'decimal'  then 'System.Double'
			when  'float'  then  'System.Double'
			when  'int'  then 'System.Int32'
			when  'money'  then 'System.Double'
			when  'numeric'  then 'System.Double'
			when  'real'  then 'System.Double'
			when  'smalldatetime'  then 'System.DateTime'
			when  'smallint'  then 'System.Int32'
			when  'smallmoney'  then 'System.Double'
			when  'varchar'  then 'System.String'
			when  'nvarchar'  then 'System.String'
			else  T.name
		end AS Tipo	, c.colorder
		from   syscolumns C , sysTypes  T	
		where C.id =  @id
		and   C.xtype = T.xtype
		AND   C.NAME  IN (Select C.Name
					from   syscolumns C ,    SysIndexes I , SysIndexkeys K 
					where C.id =  @id
					and   I.id = C.id
					and   I.name like 'PK_%'
					and   K.id = C.id
					and   K.indid = I.indid
					and   K.Colid = C.Colid)
		order by c.colorder

	OPEN Lista

	Set @Fields  = ''
	Set @Values  = ''
	Set @Primero = 1 

	FETCH NEXT FROM Lista INTO @Campo, @tIPO , @Order
	WHILE @@FETCH_STATUS = 0 BEGIN
			
		if @Primero = 1 begin
		    set @Primero	= 0 
		    if @tIPO <> 'System.String' begin
 				  Set @Fields = '           " Where     ' + @Campo + '=" & _'+ @Campo + '.ToString() '
			  end 
			  else begin
				  Set @Fields = '           " Where     ' + @Campo + '=' + char(39) + '" & _' + @Campo + ' & "' + char(39) + '"'
			  end 
		end 
		else begin
		    if @tIPO <> 'System.String' begin
 				Set @Fields = @Fields + ' & _ ' + char(13) + '           " And    ' + @Campo + '=" & _'+ @Campo + '.ToString() '
			end 
			else begin
				Set @Fields = @Fields + ' & _ ' + char(13) + '           " And     ' + @Campo + '=' + char(39) + '" & _' + @Campo + ' & "' + char(39) + '"'
			end 
		end
	
		FETCH NEXT FROM Lista INTO @Campo, @tIPO, @Order
	END
	CLOSE Lista
	DEALLOCATE Lista

	print @Fields + ' '
end

GO


