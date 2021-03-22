package com.emids.da;

import java.util.List;

public class PortalException extends RuntimeException {
  private static final long serialVersionUID = 936663604518978906L;

  // Error Code associated with exception, describes the exception type.
  private String errorCode;

  // List contains arguments to prepare the customized message from properties
  // file
  private List<String> messageArguments;

  /**
   * Constructor for PortalException.
   *
   * @param message String
   */
  public PortalException(final String message) {
    super(message);
  }

  /**
   * Constructor for PortalException.
   *
   * @param message String
   * @param cause   Throwable
   */
  public PortalException(final String message, final Throwable cause) {
    super(message, cause);
  }

  /**
   * Constructor for PortalException.
   *
   * @param cause Throwable
   */
  public PortalException(final Throwable cause) {
    super(cause);
  }

  /**
   * Constructor for PortalException.
   *
   * @param message   String
   * @param errorCode String
   */
  public PortalException(final String message, final String errorCode) {
    super(message);
    this.errorCode = errorCode;
  }

  /**
   * Constructor for PortalException.
   *
   * @param message   String
   * @param cause     Throwable
   * @param errorCode String
   */
  public PortalException(final String message, final Throwable cause, final String errorCode) {
    super(message, cause);
    this.errorCode = errorCode;
  }

  /**
   * Get the error code asociated with this exception.
   *
   * @return the errorCode String
   */
  public final String getErrorCode() {
    return errorCode;
  }

  /**
   * Set the error code for this exception.
   *
   * @param errorCode String
   */
  public final void setErrorCode(final String errorCode) {
    this.errorCode = errorCode;
  }

  /**
   * Get the arguments list for this exception.
   *
   * @return list of arguments
   */
  public final List<String> getMessageArguments() {
    return messageArguments;
  }

  /**
   * Set the arguments list for this exception.
   *
   * @param messageDetails List
   */
  public final void setMessageArguments(final List<String> messageDetails) {
    this.messageArguments = messageDetails;
  }
}
