﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    //public class GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>
    //{
    //    public int Id { get; } = Id;
    //}

    public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
}
