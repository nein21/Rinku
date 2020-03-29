
CREATE PROCEDURE [dbo].[OBTENERPAGOEMPLEADO]
	@IdEmpleado INT = 0
	
AS
	declare	@iMaxFolio int = 0 ,
			@Empleado int = 0,
			@FolioCaptura int =0,
			@nombre varchar(120) = '' , 
			@iSueldoBaseTotal int = 0 ,
			@iBonoTotal int = 0 ,
			@iCantidadTotal int = 0 ,
			@dValesDespensa money = 0 ,
			@dTotal money = 0 ,
			@dISR money = 0 ,
			@dTotalPagar money = 0,
			--Variables de uso interno
			@idEmpleadoCaptura int = 0,
			@EmpleadoId int = 0,
			@rol int = 0 ,
			@tipo int = 0, 
			@bono int = 0,
			@CantidadEntregas int = 0,
			@subtotal int = 0

IF @IdEmpleado = 0
	begin
		PRINT 'ERROR: parametro IdeEmpleado no recibido'  
		
       --RETURN(-1)
	end
else	
		set @iMaxFolio = (select ISNULL( max(foliopagar),0) from PagoEmpleado);
		if @iMaxFolio =0
			set @iMaxFolio =1;
		else 
			set @iMaxFolio = @iMaxFolio+1;

		select @idEmpleadoCaptura = ISNULL(idempleado,0), 
				@FolioCaptura = ISNULL(folio,0)
		from capturafolio where idempleado = @IdEmpleado and idpagoempleado = 0;
		
		select
			@EmpleadoId = ISNULL( max(idempleado),0),
			@nombre = concat(nombre,' ',apaterno,' ',amaterno),
			@rol = rol,
			@tipo = tipo
			from empleado where idempleado = @IdEmpleado group by idempleado,nombre,apaterno,amaterno,rol,tipo;
		--select nombre, apaterno,amaterno from empleado 
		if @EmpleadoId = 0
			begin
				set @iMaxFolio = -1;
				set @nombre = 'Numero de empleado no existe';
			end
		else if @idEmpleadoCaptura = 0
			begin
				set @iMaxFolio = -2;
				set @nombre = 'Ya se le realizo el pago al empleado';
			end
		else
			begin
				if @rol = 1
					set @bono = 10;
				else if @rol = 2
					set @bono = 5;
				else
					set @bono = 0;


				SELECT @CantidadEntregas =  SUM(cantidad) FROM capturafolio WHERE idempleado = @IdEmpleado and idpagoempleado=0;
				set @iSueldoBaseTotal = 30*40;--40Horas
				set @iBonoTotal = @bono*40;
				set @iCantidadTotal = 5*@CantidadEntregas;
				set @subtotal = @iSueldoBaseTotal + @iBonoTotal + @iCantidadTotal;
				

				if @tipo =1
					set @dValesDespensa  = @subtotal*0.04;

				set @dTotal = @subtotal + @dValesDespensa;

				if @dTotal > 1600
					set @dISR = @dTotal*0.12;
				else
					set @dISR = @dTotal*0.09;

				set @dTotalPagar = @dTotal-@dISR ;
			end
		
		select @iMaxFolio as foliopagar,@FolioCaptura as foliocaptura,@IdEmpleado as empleado,@nombre as nombres,@iSueldoBaseTotal as sueldobase,@iBonoTotal as bonotrabajo,
				@iCantidadTotal as entregas ,@dValesDespensa as vales,@dTotal as total,@dISR as isr,@dTotalPagar as totalpagar;
	