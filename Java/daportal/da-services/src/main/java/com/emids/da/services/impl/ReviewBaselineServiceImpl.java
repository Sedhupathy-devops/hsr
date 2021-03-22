package com.emids.da.services.impl;

import com.emids.da.model.ReviewBaseline;
import com.emids.da.repository.ReviewBaselineRepository;
import com.emids.da.services.ReviewBaselineService;
import com.google.inject.Inject;

import java.util.List;

public class ReviewBaselineServiceImpl implements ReviewBaselineService {

  @Inject
  private ReviewBaselineRepository reviewBaselineRepository;

  /**
   * Retrieve list of projects whose rating are NON-GREEN based on IR Rating
   *
   * @param months months
   * @param years  year
   * @return list of reviews
   */
  @Override
  public List<ReviewBaseline> getNonGreenProjectsForQuarter(String months, String years) {

    return reviewBaselineRepository.getNonGreenProjectsForQuarter(months, years);
  }

  /**
   * Returns all projects that has any scores less than 60 and nternal rating as GREEN
   *
   * @param months months
   * @param years  years
   * @return list of projects
   */
  public List<ReviewBaseline> getProjectsWithScoresBelowThreshold(final String months, final String years) {

    return reviewBaselineRepository.getProjectsWithScoresBelowThreshold(months, years);
  }

}
