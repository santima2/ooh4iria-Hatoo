
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;
using DSMGen.ApplicationCore.CEN.DSM1;
using DSMGen.ApplicationCore.Utils;



namespace DSMGen.ApplicationCore.CP.DSM1
{
public partial class ValoracionCP : GenericBasicCP
{
public ValoracionCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public ValoracionCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
