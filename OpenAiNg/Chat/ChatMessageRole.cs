﻿using System;

namespace OpenAiNg.Chat;

/// <summary>
///     Represents the Role of a <see cref="ChatMessage" />.  Typically, a conversation is formatted with a system message
///     first, followed by alternating user and assistant messages.  See
///     <see href="https://platform.openai.com/docs/guides/chat/introduction">the OpenAI docs</see> for more details about
///     usage.
/// </summary>
public class ChatMessageRole : IEquatable<ChatMessageRole>
{
	/// <summary>
	///     Contructor is private to force usage of strongly typed values
	/// </summary>
	/// <param name="value"></param>
	private ChatMessageRole(string value)
    {
        Value = value;
    }

    private string Value { get; }

    /// <summary>
    ///     The system message helps set the behavior of the assistant.
    /// </summary>
    public static ChatMessageRole System { get; } = new("system");

    /// <summary>
    ///     The user messages help instruct the assistant. They can be generated by the end users of an application, or set by
    ///     a developer as an instruction.
    /// </summary>
    public static ChatMessageRole User { get; } = new("user");

    /// <summary>
    ///     The assistant messages help store prior responses. They can also be written by a developer to help give examples of
    ///     desired behavior.
    /// </summary>
    public static ChatMessageRole Assistant { get; } = new("assistant");

    /// <summary>
    ///     The function role can be used in models which support function access.
    /// </summary>
    public static ChatMessageRole Function { get; } = new("function");

    /// <summary>
    ///     Determines whether this instance and a specified object have the same value.
    /// </summary>
    /// <param name="other">The ChatMessageRole to compare to this instance</param>
    /// <returns>
    ///     true if other's value is the same as this instance; otherwise, false. If other is null, the method returns
    ///     false
    /// </returns>
    public bool Equals(ChatMessageRole? other)
    {
        return other != null && Value.Equals(other.Value);
    }

    /// <summary>
    ///     Gets the singleton instance of <see cref="ChatMessageRole" /> based on the string value.
    /// </summary>
    /// <param name="roleName">Muse be one of "system", "user", "assistant", or "function"</param>
    /// <returns></returns>
    public static ChatMessageRole? FromString(string roleName)
    {
        return roleName switch
        {
            "system" => System,
            "user" => User,
            "assistant" => Assistant,
            "function" => Function,
            _ => null
        };
    }

    /// <summary>
    ///     Gets the string value for this role to pass to the API
    /// </summary>
    /// <returns>The size as a string</returns>
    public override string ToString()
    {
        return Value;
    }

    /// <summary>
    ///     Determines whether this instance and a specified object have the same value.
    /// </summary>
    /// <param name="obj">The ChatMessageRole to compare to this instance</param>
    /// <returns>
    ///     true if obj is a ChatMessageRole and its value is the same as this instance; otherwise, false. If obj is null,
    ///     the method returns false
    /// </returns>
    public override bool Equals(object? obj)
    {
        return Value.Equals((obj as ChatMessageRole)?.Value);
    }

    /// <summary>
    ///     Returns the hash code for this object
    /// </summary>
    /// <returns>A 32-bit signed integer hash code</returns>
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    /// <summary>
    ///     Gets the string value for this role to pass to the API
    /// </summary>
    /// <param name="value">The ChatMessageRole to convert</param>
    public static implicit operator string(ChatMessageRole value)
    {
        return value.Value;
    }
}