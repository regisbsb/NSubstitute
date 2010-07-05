﻿using System;

namespace NSubstitute.Core
{
    public class SubstituteState
    {
        public SubstituteState(ISubstitutionContext substitutionContext)
        {
            CallInfoFactory = new CallInfoFactory();
            CallStack = new CallStack();
            CallResults = new CallResults(CallInfoFactory);
            CallActions = new CallActions();
            PropertyHelper = new PropertyHelper();
            CallSpecificationFactory = new CallSpecificationFactory(substitutionContext, new ArgumentSpecificationFactory(new MixedArgumentSpecificationFactory()));
            ResultSetter = new ResultSetter(CallStack, CallResults, CallSpecificationFactory);
            EventHandlerRegistry = new EventHandlerRegistry();
            CallNotReceivedExceptionThrower = new CallNotReceivedExceptionThrower(new CallFormatter(new ArgumentFormatter()));
            CallReceivedExceptionThrower = new CallReceivedExceptionThrower(new CallFormatter(new ArgumentFormatter()));
        }

        public CallStack CallStack { get; private set; }
        public ICallResults CallResults { get; private set; }
        public IPropertyHelper PropertyHelper { get; private set; }
        public ICallSpecificationFactory CallSpecificationFactory { get; private set; }
        public IResultSetter ResultSetter { get; private set; }
        public IEventHandlerRegistry EventHandlerRegistry { get; private set; }
        public ICallActions CallActions { get; private set; }
        public CallInfoFactory CallInfoFactory { get; private set; }
        public ICallNotReceivedExceptionThrower CallNotReceivedExceptionThrower { get; private set; }
        public ICallReceivedExceptionThrower CallReceivedExceptionThrower { get; private set; }
    }
}