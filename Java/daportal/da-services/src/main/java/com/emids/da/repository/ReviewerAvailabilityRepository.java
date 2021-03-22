package com.emids.da.repository;

import com.emids.da.model.ReviewerAvailability;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class ReviewerAvailabilityRepository extends AbstractRepository<ReviewerAvailability> {

  @Override
  public ReviewerAvailability findById(Long id) {
    return find(ReviewerAvailability.class, id);
  }
}
